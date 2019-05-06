using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RyansEventManager.Models
{
    public class OrderCart
    {
        public string OrderCartId;

        private RyansEventManagerDB db = new RyansEventManagerDB();

        public static OrderCart GetCart(HttpContextBase context)
        {
            OrderCart cart = new OrderCart();
            cart.OrderCartId = cart.GetCartId(context);
            return cart;
        }

        private string GetCartId(HttpContextBase context)
        {
            const string CartSessionId = "CartId";

            string cartId;

            if (context.Session[CartSessionId] == null)
            {
                cartId = Guid.NewGuid().ToString();

                context.Session[CartSessionId] = cartId;
            }
            else
            {
                cartId = context.Session[CartSessionId].ToString();
            }

            return cartId;
        }

        public List<Order> GetCartItems()
        {
            return db.Orders.Where(o => o.OrderId == this.OrderCartId).ToList();
        }

        public void AddToCart(int eventId)
        {
            Order cartItem = db.Orders.SingleOrDefault(o => o.OrderId == this.OrderCartId && o.EventId == eventId);

            if (cartItem == null)
            {
                cartItem = new Order()
                {
                    OrderId = this.OrderCartId,
                    EventId = eventId,
                    Tickets = 1,
                    DateCreated = DateTime.Now
                };
                db.Orders.Add(cartItem);
            }
            else
            {
                cartItem.Tickets++;
            }
            db.SaveChanges();


        }

        public int RemoveFromCart(int recordId)
        {

            Order cartItem = db.Orders.SingleOrDefault(c => c.OrderId == this.OrderCartId && c.RecordId == recordId);

            if (cartItem == null)
            {
                throw new NullReferenceException();
            }

            int newCount;

            if (cartItem.Tickets > 1)
            {
                cartItem.Tickets--;
                newCount = cartItem.Tickets;
            }
            else
            {
                db.Orders.Remove(cartItem);
                newCount = 0;

            }

            db.SaveChanges();

            return newCount;
        }




    }

}
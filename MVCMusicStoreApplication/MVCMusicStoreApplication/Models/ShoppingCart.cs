using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId;

        private MVCMusicStoreDBContext db = new MVCMusicStoreDBContext();

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();

            cart.ShoppingCartId = cart.GetCartId(context);

            return cart;
        }  

        private string GetCartId(HttpContextBase context)
        {
            const string CartSessionId = "CartId";

            

            string cartId;

            if (context.Session[CartSessionId] == null)
            {
                //Create a new cart Id
                cartId = Guid.NewGuid().ToString();

                //Save ti the session state
                context.Session[CartSessionId] = cartId;
            }
            else
            {
                //REturn the existing cart id
                cartId = context.Session[CartSessionId].ToString();
            }


            return cartId;

        }
        
        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartID == this.ShoppingCartId).ToList();
            
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from cartITem in db.Carts
                        where cartITem.CartID == this.ShoppingCartId
                        select cartITem.AlbumSelected.Price * (int?)cartITem.Count).Sum() ;

            return total ?? decimal.Zero; 
        }

        public void AddToCart(int albumId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartID == this.ShoppingCartId && c.AlbumID == albumId);

            if(cartItem == null)
            {
                cartItem = new Cart()
                {
                    CartID = this.ShoppingCartId,
                    AlbumID = albumId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();

        }

        public int RemoveFromCart(int recordId)
        {

            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartID == this.ShoppingCartId && c.RecordID == recordId);

            if(cartItem == null)
            {
               throw new NullReferenceException();
            }

            int newCount;

            if(cartItem.Count > 1)
            {
                cartItem.Count--;
                newCount = cartItem.Count;
            }
            else
            {
                db.Carts.Remove(cartItem);
                newCount = 0;

            }

            db.SaveChanges();

            return newCount;
        }

    }

    
} 
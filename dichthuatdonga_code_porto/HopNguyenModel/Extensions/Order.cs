using System;
using System.Collections.Generic;
using System.Linq;

namespace HopNguyenModel.Extensions
{
    [Serializable]
    public class Order
    {
        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        /// <summary>
        /// object order null
        /// </summary>

        public Order()
        {
        }


        public Order(int count, int productId)
        {
            this._count = count;
            this._productId = productId;
        }

        public List<Order> AddCart(List<Order> list, int pId, int count)
        {
            try
            {
                if (list.SingleOrDefault(o => o.ProductId == pId) != null)
                {
                    foreach (var item in list.Where(item => item.ProductId == pId))
                    {
                        item.Count = item.Count + count;
                        break;
                    }
                }
                else
                {
                    list.Add(new Order(1, pId));
                }
                return list;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> Update(List<Order> list, int pId, int count)
        {
            try
            {
                if (list.SingleOrDefault(o => o.ProductId == pId) != null)
                {
                    foreach (var item in list.Where(item => item.ProductId == pId))
                    {
                        item.Count = count;
                        break;
                    }
                }
                else
                {
                    list.Add(new Order(1, pId));
                }
                return list;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// delete item order
        /// </summary>
        /// <param name="list">list order</param>
        /// <param name="pId">id of product need delete</param>
        /// <returns>list order</returns>
        public List<Order> Delete(List<Order> list, int pId)
        {
            try
            {
                list.RemoveAll(o => o.ProductId == pId);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class OrderDetail : Order
    {
        public Content Product { get; set; }

        public OrderDetail() { }

        public OrderDetail(int count, int productId)
        {
            Count = count;
            ProductId = productId;
            Product = new HopNguyenEntities().Contents.FirstOrDefault(p => p.Id == productId);

        }

        public List<OrderDetail> ListAll(List<Order> list)
        {
            return list.Select(item => new OrderDetail(item.Count, item.ProductId)).ToList();
        }

        /// <summary>
        /// insert order to data base 
        /// </summary>
        /// <param name="list">list order</param>
        /// <param name="order">information of customer</param>
        public void InsertOrder(List<Order> list, HopNguyenModel.Order order)
        {
            using (var db = new HopNguyenEntities())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                foreach (var item in ListAll(list))
                {
                    var orderDetail = new HopNguyenModel.OrderDetail
                                          {
                                              Count = item.Count,
                                              OrderId = order.Id,
                                              Price = item.Product.Price,
                                              ContentId = item.Product.Id
                                          };
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                }
            }
        }

    }
}

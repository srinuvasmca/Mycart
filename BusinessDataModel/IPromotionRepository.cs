using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace BusinessDataModel
{
    interface IPromotionRepository
    {
        IEnumerable<PromotionModel> GetAll();
        PromotionModel GetByNo(int id);
        int Update(PromotionModel model);
        int Add(PromotionModel model);
        int Delete(int id);
        IEnumerable<CartModel> GetCartByName(string name);
        PromotionModel GetCalPromotion(string Name);
    }
}
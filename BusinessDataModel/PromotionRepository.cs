using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using AutoMapper;

namespace BusinessDataModel
{
    public class PromotionRepository: IPromotionRepository
    {

        private readonly CheckOutProcessEntities _context;


        public PromotionRepository()
        {
            _context = new CheckOutProcessEntities();
            
            Mapper.Initialize(cfg => cfg.CreateMap<tblBasePromotion, PromotionModel>());
            
        }    
        

        //public MyContactsRepository(SampleDBEntities context)   
        //{  
        //    _context = context;  
        //} 

        /// <summary>
        /// Method return all contacts list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PromotionModel> GetAll()
        {

           
            var tmodel = from e in _context.tblSKUIDS
                         join d in _context.tblBasePromotions on e.SKUId equals d.SKUID
                         select new PromotionModel()
                         {
                             PromotionId = d.PromotionId,
                             PromotionName = d.PromotionName,
                             SKUName = e.Name,                    
                             SKUIDQuantity = d.SKUIDQuantity,
                             PromotionUnitPrice= d.PromotionUnitPrice,
                             Active = d.Active,
                             AddedOn = d.AddedOn
                         };

            IEnumerable<PromotionModel> model = Mapper.Map<IEnumerable<PromotionModel>>(tmodel.ToList());


            return model;

        }

        /// <summary>
        /// Method returns contact details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PromotionModel GetByNo(int id)
        {
            PromotionModel model = new PromotionModel();
            model = Mapper.Map<PromotionModel>(_context.tblBasePromotions.Find(id));
            return model;
        }

        /// <summary>
        /// Method returns contact details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<CartModel> GetCartByName(string name)
        {
            //model = Mapper.Map<PromotionModel>(_context.tblBasePromotions.Find(id));

            Mapper.Initialize(cfg => cfg.CreateMap<tblCart, CartModel>());

            var tmodel = from e in _context.tblSKUIDS
                         join d in _context.tblCarts on e.SKUId equals d.SKUID
                         where d.CustomerName == "Srinivas"
                         select new CartModel()
                         {
                             SKUID = e.SKUId,
                             SKUName = e.Name,
                             UnitPrice = e.UnitPrice,
                             SKUIDQuantity = d.Quantity
                         };

            IEnumerable<CartModel> model = Mapper.Map<IEnumerable<CartModel>>(tmodel.ToList());

            return model;
        }

        /// <summary>
        /// Method to update contact details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(PromotionModel model)
        {
            int res;
            int no = Convert.ToInt32(model.PromotionId);
            var checkcontactList = _context.tblBasePromotions.Where(x => x.PromotionName == model.PromotionName && x.PromotionId != no).FirstOrDefault();

            if (checkcontactList != null)
            {
                res = 4;
            }
            else
            {
                var promotionList = _context.tblBasePromotions.Where(x => x.PromotionId == no).FirstOrDefault();
                promotionList.PromotionName = model.PromotionName;
                promotionList.SKUID = 2;
                promotionList.SKUIDQuantity = model.SKUIDQuantity;
                promotionList.PromotionUnitPrice = model.PromotionUnitPrice;
                promotionList.UpdatedOn = System.DateTime.Now;
                res = _context.SaveChanges();
            }

            return 1;
        }


        /// <summary>
        /// Method to update contact details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PromotionModel GetCalPromotion(string Name)
        {
            PromotionModel model = new PromotionModel();
            model = Mapper.Map<PromotionModel>(_context.tblBasePromotions.Where(x => x.PromotionName == Name).FirstOrDefault());
            return model;
        }


        /// <summary>
        /// Method to add contact details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public int Add(PromotionModel model)
        {

            var promotionlist = _context.tblBasePromotions.Where(x => x.PromotionName == model.PromotionName).FirstOrDefault();
            int res;

            if (promotionlist != null)
            {
                res = 4;
            }
            else
            {
                model.AddedOn = DateTime.Now;
                Mapper.Initialize(cfg => cfg.CreateMap<PromotionModel, tblBasePromotion>());
                _context.tblBasePromotions.Add(Mapper.Map<tblBasePromotion>(model));
                res = _context.SaveChanges();
            }
            return res;
        }

        /// <summary>
        /// Method to delete contact details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public int Delete(int id)
        {

            var promotionList = _context.tblBasePromotions.Where(x => x.PromotionId == id).FirstOrDefault();
            _context.tblBasePromotions.Remove(promotionList);
            int res = _context.SaveChanges();

            return 1;
        }

    }
}
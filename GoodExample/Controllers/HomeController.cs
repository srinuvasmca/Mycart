using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using BusinessDataModel;
using BusinessEntities;

namespace GoodExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public readonly PromotionRepository _myPromotions;

        /// <summary>
        /// Contructor
        /// </summary>
        public HomeController()
        {
            _myPromotions = new PromotionRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method to fetch all records
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAll()
        {
            var contactList = _myPromotions.GetAll();
            return Json(contactList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Method to fetch by contact id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetPromotionById(string Id)
        {

            var promotionList = _myPromotions.GetByNo(Convert.ToInt32(Id));
            return Json(promotionList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Method to fetch by contact id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        
        public JsonResult GetCalcPromotion([FromUri]string pname)
        {
            var promotionList = _myPromotions.GetCalPromotion(pname);
            return Json(promotionList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Method to fetch by contact id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult GetCartByName()
        {
            string name = "Srinivas";
            var cartList = _myPromotions.GetCartByName(name);
            return Json(cartList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Method to update contact details
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public string UpdatePromotion(PromotionModel cnt)
        {
            if (cnt != null)
            {
                int result = _myPromotions.Update(cnt);

                if (result == 1)
                    return "Promotion Updated";
                else if (result == 4)
                    return "Promotion name already exists..";
                else
                    return "Invalid Promotion";
            }
            else
            {
                return "Invalid Promotion";
            }
        }

        /// <summary>
        /// Method to add new contact
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public string AddPromotion(PromotionModel cnt)
        {
            if (cnt != null)
            {

                int result = _myPromotions.Add(cnt);

                if (result == 1)
                    return "Promotion Added";
                else if (result == 4)
                    return "Promotion name already exists";
                else
                    return "Invalid Promotion";
            }
            else
            {
                return "Invalid Promotion";
            }
        }

        /// <summary>
        /// Method to delete contact
        /// </summary>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public string DeletePromotion(PromotionModel cnt)
        {
            if (cnt != null)
            {

                int no = Convert.ToInt32(cnt.PromotionId);
                int result = _myPromotions.Delete(no);

                if (result == 1)
                    return "Promotion Deleted";

                else
                    return "Invalid Promotion";
            }
            else
            {
                return "Invalid Promotion";
            }
            

        }
    }
}

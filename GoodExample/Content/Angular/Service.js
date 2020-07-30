app.service("angularService", function ($http) {

    ////get All Contacts
    this.getPromotions = function () {
        debugger;
        return $http.get("Home/GetAll");
    };

    // get Contact By Id
    this.getPromotion = function (contactID) {
        var response = $http({
            method: "post",
            url: "Home/GetPromotionById",
            params: {
                id: JSON.stringify(contactID)
            }
                       
        });
        return response;
    }

    // get Contact By Id

    ////get All Contacts
    this.GetCartInfo = function () {
        
        return $http.get("Home/GetCartByName");
    };
    
    // get Contact By Id
    this.CalcPromotion = function (name) {
        
        var response = $http({
            method: "post",
            url: "Home/GetCalcPromotion",
            params: {
                pname: name
            }

        });
        return response;
    }

    // Update Contact 
    this.updatePromotion = function (contact) {
        var response = $http({
            method: "post",
            url: "Home/UpdatePromotion",
            data: JSON.stringify(contact),
            dataType: "json"
        });
        return response;
    }

    // Add Contact
    this.AddPromotion = function (contact) {
        var response = $http({
            method: "post",
            url: "Home/AddPromotion",
            data: JSON.stringify(contact),
            dataType: "json"
        });
        return response;
    }

    //Delete Contact
    this.DeletePromotion = function (promotion) {
        var response = $http({
            method: "post",
            url: "Home/DeletePromotion",
            data: JSON.stringify(promotion),
            dataType: "json"
            //params: {
            //    employeeId: JSON.stringify(employeeId)
            // }
        });
        return response;
    }
});
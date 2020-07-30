app.controller("myCntrl", function ($scope, angularService) {

    
    $scope.divContact = false;
    $scope.divList = false;
    GetAllContact();
    //To Get All Records  
    function GetAllContact() {
        
        var getData = angularService.getContacts();
        getData.then(function (cnt) {
            $scope.contacts = cnt.data;
        },function () {
            alert('Error in getting records');
        });
    }

    $scope.editContact = function (contact) {
        debugger;
        var getData = angularService.GetEmployeeById(contact.Id);
        alert(contact.id);
        alert(getData);
        getData.then(function (cnt) {
            $scope.contact = cnt.data;
            $scope.contactId = cnt.Id;
            $scope.contactName = cnt.Name;
            $scope.contactPhoneNumber = cnt.phoneNumber;           
            $scope.Action = "Update";
            $scope.divContact = true;
            alert('Error');
        }, function () {+++++++++++++++++++++++++++++++++++++++++++++++++++
            alert('Error in getting records');
        });
    }

    $scope.AddUpdatePromotion = function ()
    {
       
        alert("Fun");
        var Promotion = {
            PromotionName: $scope.PromotionName,
            SKUID: 1,
            SKUIDQuantity: $scope.SKUIDUnitQuantity,
            PromotionUnitPrice: $scope.PromotionUnitPrice
        };
        var getAction = $scope.Action;
        alert(getAction);
        if (getAction == "Update") {
            Contact.Id = $scope.contactId;
            var getData = angularService.updateContact(Promotion);
            getData.then(function (msg) {
                GetAllContact();
                alert(msg.data);
                $scope.divContact = false;
            }, function () {
                alert('Error in updating record');
            });
        } else {
            debugger;
            var getData = angularService.AddPromotion(Promotion);
            getData.then(function (msg) {
                GetAllContact();
                alert(msg.data);
                $scope.divContact = false;
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.AddContactDiv=function()
    {
        ClearFields();
        $scope.Action = "Add";
        $scope.divContact = true;
        $scope.divList = true;
    }

    $scope.deleteContact = function (contact)
    {
        var getData = angularService.DeleteContact(contact.Id);
        getData.then(function (msg) {
            GetAllContact();
            alert('Contact Deleted');
        },function(){
            alert('Error in Deleting Record');
        });
    }

    function ClearFields() {
        $scope.contactId = "";
        $scope.contactName = "";
        $scope.contactPhoneNummber = ""
        
    }


   

});
app.controller("myCntrl", function ($scope, angularService) {
    $scope.divList = false;
    $scope.divContact = false;
    $scope.divCheckOutList = false;
    $scope.pname = "";
    //To Get All Records  
    function GetAllPromotions() {
       
        var getData = angularService.getPromotions();
        getData.then(function (cnt) {
            $scope.promotions = cnt.data;
        },function () {
            alert('Error in getting records');
        });
    }

    $scope.editPromotion = function (promotion) {
        var getData = angularService.getPromotion(promotion.PromotionId);
        ClearFields();
        getData.then(function (cnts) {
          
            $scope.promotion = cnts.data;
            $scope.PromotionId = cnts.data.PromotionId;
            $scope.PromotionName = cnts.data.PromotionName;
            $scope.SKUIDQuantity = cnts.data.SKUIDQuantity;
            $scope.PromotionUnitPrice = cnts.data.PromotionUnitPrice;
            $scope.Action = "Update";
            
            $scope.divContact = true; 
        }, function () {
            alert('Error in getting records');
        });
    }


    var cartname = "Srinivas"
    function GetCartInfo() {
       
        var getData = angularService.GetCartInfo(cartname);
        getData.then(function (cnt) {            
            $scope.carts = cnt.data;            
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.CalculatePromotion = function (pname) {
        alert("Hello");
        var getData = angularService.CalcPromotion(pname);
        getData.then(function (cnt) {             
            $scope.calcpromotion = cnt.data;
        }, function () {
            alert('No promotion found');
        });
    }

    $scope.AddUpdatePromotion = function ()
    {
        
        var Promotion = {
            PromotionName: $scope.PromotionName,
            SKUID: 2,
            SKUIDQuantity: $scope.SKUIDQuantity,
            PromotionUnitPrice: $scope.PromotionUnitPrice
        };
        var getAction = $scope.Action;             

        if (getAction == "Update") {
            Promotion.PromotionId = $scope.PromotionId;
            var getData = angularService.updatePromotion(Promotion);
            getData.then(function (msg) {
                
                if (msg.data == "Promotion name already exists..") {
                    alert(msg.data);
                    $scope.divContact = true;
                }
                else {
                    GetAllPromotions();
                    alert(msg.data);
                    $scope.divContact = false;
                }
            }, function () {
                alert('Error in updating record');
                $scope.divContact = true;
            });
        } else {
            var getData = angularService.AddPromotion(Promotion);
            getData.then(function (msg) {
                if (msg.data == "Promotion name number already exists..") {
                    alert(msg.data);
                    $scope.divContact = true;
                }
                else {
                    GetAllPromotions();
                    alert(msg.data);
                    $scope.divContact = false;
                }
            }, function () {
                alert('Error in adding record');
                $scope.divContact = true;
            });
        }
    }

    $scope.AddContactDiv=function()
    {
        ClearFields();
        GetAllPromotions();
        $scope.Action = "Add";
        $scope.divContact = true;
        $scope.divList = true;
        $scope.divCheckOutLisCt = false;
    }

    $scope.CalculateCheckOutDiv = function () {
        GetCartInfo();
        $scope.divCheckOutLisCt = true;
        $scope.divContact = false;
        $scope.divList = false;
    }

    $scope.CancelContact = function () {
        ClearFields();
        $scope.Action = "";
        $scope.divContact = false;
    }

    

    $scope.deletePromotion = function (promotion)
    {
        var getData = angularService.DeletePromotion(promotion);
        getData.then(function (msg) {
            GetAllPromotions();
            alert('Promotion Deleted');
        },function(){
            alert('Error in Deleting Record');
        });
    }

    var original = $scope.user;

    function ClearFields() {
        $scope.PromotionId = "";
        $scope.PromotionName = "";
        $scope.SKUIDQuantity = "";
        $scope.PromotionUnitPrice = "";
     
        $scope.user = angular.copy(original);
        $scope.myForm.$setPristine();
        
    }

});
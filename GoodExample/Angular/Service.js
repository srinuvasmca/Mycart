app.service("angularService", function ($http) {

    //get All Contacts
    this.getContacts = function () {
        debugger;
        return $http.get("Home/GetAll");
    };

    // get Contact By Id
    this.getContact = function (contactID) {
        var response = $http({
            method: "post",
            url: "Home/GetContactById",
            params: {
                id: JSON.stringify(contactID)
            }
        });
        return response;
    }

    // Update Contact 
    this.updateContact = function (contact) {
        var response = $http({
            method: "post",
            url: "Home/UpdateContact",
            data: JSON.stringify(contact),
            dataType: "json"
        });
        return response;
    }

    // Add Contact
    this.AddContact = function (contact) {
        var response = $http({
            method: "post",
            url: "Home/AddContact",
            data: JSON.stringify(contact),
            dataType: "json"
        });
        return response;
    }

    //Delete Contact
    this.DeleteContact = function (contactId) {
        var response = $http({
            method: "post",
            url: "Home/DeleteContact",
            params: {
                contactId: JSON.stringify(contactId)
            }
        });
        return response;
    }
});
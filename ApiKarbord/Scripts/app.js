var ViewModel = function () {

    var self = this;
    var ace = $("#ace").val();
    var sal = $("#sal").val();
    var group = $("#group").val();
    var server = $("#server").val();

    self.DocNoMode = ko.observable();
    self.InsertMode = ko.observable();
    self.ModeCode = ko.observable();
    self.SerialNumber = ko.observable();
    self.DocNo = ko.observable();
    self.StartNo = ko.observable();
    self.EndNo = ko.observable();

    self.FactorList = ko.observableArray([]);

    var FactorUri = '/api/Factor/';

    function ajaxFunction(uri, method, data) {
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data
                ?
                JSON.stringify(data)
                :
                null

        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('خطا : ' + errorThrown);
        });
    }

    // Clear Fields  
    self.clearFields = function clearFields() {
        self.DocNoMode('');
        self.InsertMode('');
        self.ModeCode('');
        self.SerialNumber('');
        self.DocNo('');
        self.StartNo('');
        self.EndNo('');
    };

    //Add new Factor  
    self.addNewFactor = function addNewFactor(newFactor) {
        var FactorObject = {
            DocNoMode : self.DocNoMode(),
            InsertMode : self.InsertMode(),
            ModeCode : self.ModeCode(),
            SerialNumber : self.SerialNumber(),
            DocNo : self.DocNo(),
            StartNo : self.StartNo(),
            EndNo : self.EndNo()
        };
        //
        ajaxFunction(FactorUri + ace + '/' + sal + '/' + group, 'POST', FactorObject).done(function () {
            self.clearFields();
            Swal.fire({ type: 'success', title: 'ثبت موفق', text: 'هدر فاکتور ذخیره شد' });
            //alert('فاکتور با موفقیت ثبت شد !');
            //getKalaList();
        });
    };

    //Get Customer List
    function getKalaList() {
        $("div.loadingZone").show();
        ajaxFunction(FactorUri, 'GET').done(function (data) {
            $("div.loadingZone").hide();
            self.FactorList(data);
        });
    }
    getKalaList();
};

ko.applyBindings(new ViewModel());  


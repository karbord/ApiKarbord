var ViewModel = function () {
    var self = this;
    var ace = $("#ace").val();
    var sal = $("#sal").val();
    var group = $("#group").val();
    var server = $("#server").val();
    var bandnumber = 0;
    var table = '';

    self.SerialNumber = ko.observable();
    self.DocDate = ko.observable();
    self.Spec = ko.observable();
    self.CustCode = ko.observable();
    self.PriceCode = ko.observable();

    self.BandNo = ko.observable();
    self.KalaCode = ko.observable();
    self.Amount1 = ko.observable();
    self.Amount2 = ko.observable();
    self.Amount3 = ko.observable();
    self.UnitPrice = ko.observable();
    self.Discount = ko.observable();
    self.MainUnit = ko.observable();
    self.Comm = ko.observable();

    /*self.DOCNOMODE = ko.observable('0');
    self.INSERTMODE = ko.observable('0');
    self.MODECODE = ko.observable('52');
    self.DOCNO = ko.observable('0');
    self.STARTNO = ko.observable('0');
    self.ENDNO = ko.observable('0');
    self.BRANCHCODE = ko.observable('0');
    self.USERCODE = ko.observable('ace');

    self.SERIALNUMBER = ko.observable();
    self.DOCDATE = ko.observable();
    self.SPEC = ko.observable();
    self.CUSTCODE = ko.observable();
    self.KALAPRICECODE = ko.observable();


    self.DOCTIME = ko.observable(null);
    self.MDOCDATE = ko.observable(null);
    self.TANZIM = ko.observable(null);
    self.TAHIESHODE = ko.observable(null);
    self.VSTRCODE = ko.observable(null);
    self.VSTRPER = ko.observable(null);
    self.PAKHSHCODE = ko.observable(null);
    self.ADDMINSPEC = ko.observable(null);
    self.ADDMINSPEC2 = ko.observable(null);
    self.ADDMINSPEC3 = ko.observable(null);
    self.ADDMINSPEC4 = ko.observable(null);
    self.ADDMINSPEC5 = ko.observable(null);
    self.ADDMINSPEC6 = ko.observable(null);
    self.ADDMINSPEC7 = ko.observable(null);
    self.ADDMINSPEC8 = ko.observable(null);
    self.ADDMINSPEC9 = ko.observable(null);
    self.ADDMINSPEC10 = ko.observable(null);
    self.ADDMINPRICE1 = ko.observable(null);
    self.ADDMINPRICE2 = ko.observable(null);
    self.ADDMINPRICE3 = ko.observable(null);
    self.ADDMINPRICE4 = ko.observable(null);
    self.ADDMINPRICE5 = ko.observable(null);
    self.ADDMINPRICE6 = ko.observable(null);
    self.ADDMINPRICE7 = ko.observable(null);
    self.ADDMINPRICE8 = ko.observable(null);
    self.ADDMINPRICE9 = ko.observable(null);
    self.ADDMINPRICE10 = ko.observable(null);*/

    self.CustList = ko.observableArray([]); // لیست حساب ها
    self.KalaList = ko.observableArray([]); // لیست کالا ها
    self.KalaPriceList = ko.observableArray([]); // لیست گروه قیمت
    self.FDocB = ko.observableArray([]); // لیست فاکتور

    var CustUri = '/api/Web_Data/Cust/'; // آدرس حساب
    var KalaUri = '/api/Web_Data/Kala/'; // آدرس کالا ها
    var KalaPriceUri = '/api/Web_Data/KalaPrice/'; // آدرس گروه قیمت
    var FDocHUri = '/api/AFI_FDocHi/'; // آدرس هدر فاکتور 
    var FDocBUri = '/api/AFI_FDocBi/'; // آدرس بند فاکتور 

    function ajaxFunction(uri, method, data) {
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('خطا : ' + errorThrown);
            });
    }

    /*
     
        function ajaxFunction(uri, method, data) {
        return $.ajax({
            type: 'GET',
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
        }).done(function (data) {
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('خطا : ' + errorThrown);
        });
    }
     */


    //Get Cust List
    function getCustList() {
        $("div.loadingZone").show();
        ajaxFunction(CustUri + ace + '/' + sal + '/' + group, 'GET').done(function (data) {
            $("div.loadingZone").hide();
            self.CustList(data);
            table = 'CustList';
        });
    }

    //Get kala List
    function getKalaList() {
        $("div.loadingZone").show();
        ajaxFunction(KalaUri + ace + '/' + sal + '/' + group, 'GET').done(function (data) {
            $("div.loadingZone").hide();
            self.KalaList(data);
            table = 'KalaList';
        });
    }

    //Get KalaPrice List
    function getKalaPriceList() {
        $("div.loadingZone").show();
        ajaxFunction(KalaPriceUri + ace + '/' + sal + '/' + group, 'GET').done(function (data) {
            $("div.loadingZone").hide();
            self.KalaPriceList(data);
        });
    }

    self.ClearFDocH = function ClearFDocH() {
        self.SerialNumber('0');
        self.DocDate('');
        self.Spec('');
        self.CustCode('');
        self.PriceCode('');
    };


    self.ClearFDocB = function ClearFDocB() {
        $('#codeKala').val('')
        $('#nameKala').val('')
        $('#unitName').val('')
        self.KalaCode('');
        self.Amount1('');
        self.Amount2('');
        self.Amount3('');
        self.UnitPrice('');
        self.Discount('');
        self.MainUnit('');
        self.Comm('');
    };

    //Add new FDocH  
    self.AddFDocH = function AddFDocH(newFDocH) {
        var codeHesab = $("#codeHesab").val();
        var tarikh = $("#tarikh").val();
        bandnumber = 0;

        if (self.SerialNumber() == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: ' شماره فاکتور را وارد کنید ' });
        }

        if (tarikh == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'تاریخ را وارد کنید' });
        }

        if (codeHesab == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'حساب را وارد کنید' });
        }

        var FDocHObject = {
            SerialNumber: self.SerialNumber(),
            DocDate: tarikh,//self.DocDate(),
            Spec: self.Spec(),
            CustCode: codeHesab,//self.CustCode(),
            KalaPriceCode: self.PriceCode(),
            UserCode: 'ace',
            BranchCode: 0,
            ModeCode: 52,
            DocNoMode: 0,
            InsertMode: 0,
            DocNo: 0,
            StartNo: 0,
            EndNo: 0,
            DocTime: 'null',
            mDocDate: 'null',
            Tanzim: 'null',
            TahieShode: 'null',
            VstrCode: 'null',
            VstrPer: 0,
            PakhshCode: '',
            AddMinSpec1: '',
            AddMinSpec2: '',
            AddMinSpec3: '',
            AddMinSpec4: '',
            AddMinSpec5: '',
            AddMinSpec6: '',
            AddMinSpec7: '',
            AddMinSpec8: '',
            AddMinSpec9: '',
            AddMinSpec10: '',
            AddMinPrice1: 0,
            AddMinPrice2: 0,
            AddMinPrice3: 0,
            AddMinPrice4: 0,
            AddMinPrice5: 0,
            AddMinPrice6: 0,
            AddMinPrice7: 0,
            AddMinPrice8: 0,
            AddMinPrice9: 0,
            AddMinPrice10: 0
        };
        ajaxFunction(FDocHUri + ace + '/' + sal + '/' + group, 'POST', FDocHObject).done(function (response) {

            $('#DatileFactor').show();
            SerialNumber = response;
            $('#serial').val(SerialNumber);
            Swal.fire({ type: 'success', title: 'ثبت موفق', text: ' مشخصات فاکتور به شماره ' + SerialNumber + ' ذخیره شد ' });
        });
    };

    //Add new FDocB  
    self.AddFDocB = function AddFDocB(newFDocB) {
        var KalaCode = $("#codeKala").val();
        var serialNumber = $("#serial").val();
        bandnumber = bandnumber + 1;

        if (serialNumber == '') {
            return Swal.fire({ type: 'danger', title: 'اطلاعات ناقص', text: ' شماره فاکتور را وارد کنید ' });
        }
        var cKala = $('#codeKala').val();
        var nKala = $('#nameKala').val();
        var uKala = $('#unitName').val();

        if (cKala == '' || nKala == '' || uKala == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'کالا را وارد کنید' });
        }

        if (self.Amount1() == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'مقدار 1 را وارد کنید' });
        }
        if (self.Amount2() == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'مقدار 2 را وارد کنید' });
        }
        if (self.Amount3() == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'مقدار 3 را وارد کنید' });
        }

        if (self.UnitPrice() == '') {
            return Swal.fire({ type: 'info', title: 'اطلاعات ناقص', text: 'قیمت را وارد کنید' });
        }



        var FDocBObject = {
            SerialNumber: serialNumber,//self.SerialNumber(),
            BandNo: bandnumber,
            KalaCode: KalaCode,
            Amount1: self.Amount1(),
            Amount2: self.Amount2(),
            Amount3: self.Amount3(),
            UnitPrice: self.UnitPrice(),
            Discount: 0,//self.Discount(),
            MainUnit: 0,//self.MainUnit(),
            Comm: self.Comm()
        };
        ajaxFunction(FDocBUri + ace + '/' + sal + '/' + group, 'POST', FDocBObject).done(function (response) {
            self.FDocB(response);
            Swal.fire({ type: 'success', title: 'ثبت موفق', text: ' بند به شماره ' + bandnumber + ' ذخیره شد ' });
            self.ClearFDocB();
        });
    };


    self.SerialNumber('0');

    $('#DatileFactor').hide();
    getCustList();
    getKalaList();
    getKalaPriceList();

    //------------------------------------------------------
    self.currentPage = ko.observable();
    self.currentPageKala = ko.observable();

    self.filter = ko.observable('');
    self.pageSize = ko.observable(10);
    self.currentPageIndex = ko.observable(1);
    self.sortType = "ascending";
    self.currentColumn = ko.observable("");
    self.iconType = ko.observable("");


    self.currentPage = ko.computed(function () {
        var pagesize = parseInt(self.pageSize(), 10),
            startIndex = pagesize * self.currentPageIndex(),
            endIndex = startIndex + pagesize;
        return self.CustList.slice(startIndex, endIndex);
    });

    self.currentPageKala = ko.computed(function () {
        var pagesize = parseInt(self.pageSize(), 10),
            startIndex = pagesize * self.currentPageIndex(),
            endIndex = startIndex + pagesize;
        return self.KalaList.slice(startIndex, endIndex);
    });

    self.nextPage = function () {
        if (((self.currentPageIndex() + 1) * self.pageSize()) < self.CustList().length) {
            self.currentPageIndex(self.currentPageIndex() + 1);
        }
        else {
            self.currentPageIndex(0);
        }
    };
    self.previousPage = function () {
        if (self.currentPageIndex() > 0) {
            self.currentPageIndex(self.currentPageIndex() - 1);
        }
        else {
            self.currentPageIndex((Math.ceil(self.CustList().length / self.pageSize())) - 1);
        }
    };

    self.firstPage = function () {
        self.currentPageIndex();
    };

    self.sortTable = function (viewModel, e) {
        var orderProp = $(e.target).attr("data-column")
        self.currentColumn(orderProp);
        self.CustList.sort(function (left, right) {
            leftVal = left[orderProp];
            rightVal = right[orderProp];
            if (self.sortType == "ascending") {
                return leftVal < rightVal ? 1 : -1;
            }
            else {
                return leftVal > rightVal ? 1 : -1;
            }
        });
        self.sortType = (self.sortType == "ascending") ? "descending" : "ascending";
        self.iconType((self.sortType == "ascending") ? "glyphicon glyphicon-chevron-up" : "glyphicon glyphicon-chevron-down");
    };

    //row select ---------------------------------
    self.select = function (item) {
        $('#codeHesab').val(item.CustCode)
        $('#nameHesab').val(item.Name)
    };

    self.selectKala = function (item) {
        $('#codeKala').val(item.Code)
        $('#nameKala').val(item.Name)
        $('#unitName').val(item.UnitName1)
    };

    self.selectFactor = function (item) {

    };
    //-------------------------------------------


    self.DeleteBand = function (factorBand) {


        ajaxFunction(FDocBUri + ace + '/' + sal + '/' + group + '/' + factorBand.SerialNumber + '/' + factorBand.BandNo, 'DELETE').done(function (response) {
            self.FDocB(response);
            Swal.fire({ type: 'success', title: 'حذف موفق', text: ' بند به شماره ' + bandnumber + ' حذف شد ' });
        });
    };
};

ko.applyBindings(new ViewModel());


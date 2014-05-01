var app = {};
app.common = {
    /* Hnadles errors for Kendo UI Grid */
    errorHandler: function (e) {
        if (e.errors) {
            var message = "Errors:\n";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function () {
                        message += this + "\n";
                    });
                }
            });
            alert(message);
        }
    },

    /* Encodes JS object like { name: "Charlie", age: 15 } to URI query string like name=Charlie&age=15 */
    encodeQueryData: function (data) {
        var ret = [];
        for (var d in data)
            ret.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
        return ret.join("&");
    },

    /* Restrict entering/selecting values that are not defined for Kendo ComboBox  */
    onChangeRestrictValues: function () {
        if (this.value() && this.selectedIndex == -1) {
            var dt = this.dataSource._data[0];
            this.text(dt[this.options.dataTextField]);
            this.select();
        }
    }
};
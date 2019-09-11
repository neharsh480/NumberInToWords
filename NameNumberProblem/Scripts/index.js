$("#StartupForm").submit(function (event) {
    
    event.preventDefault();
                $.ajax({
                    url: webApiUrl,
                    type: "POST",
                    data: { "Name": $("#Name").val(), "Number": $("#Number").val() },
                    success: function (data) {
                        $("#Result").html("");
                        $("#Result").html(data.Data.replace(' ', '<br />'));
                        $("#Result").css("color", "black");
                    },
                    error: function (data) {
                        $("#Result").html("");
                        $("#Result").html(data.responseJSON.ModelState.model[0]);
                        $("#Result").css("color", "red");
                    }
                });
 });
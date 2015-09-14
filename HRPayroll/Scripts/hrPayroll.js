function buttonnavigation() {
    //For navigating using left and right arrow of the keyboard
    try {
        $(".table1 tr td input[type='text'], .table1 tr td select").keypress(
     function (event) {
         if ((event.keyCode == 39) || (event.keyCode == 9 && event.shiftKey == false)) {
             var inputs = $(this).parents("form").eq(0).find("input[type='text'], select");
             var idx = inputs.index(this);
             if (idx == inputs.length - 1) {
                 inputs[0].select();
             } else {
                 inputs[idx + 1].focus();
                 inputs[idx + 1].select();
             }
             return false;
         };
         if ((event.keyCode == 37) || (event.keyCode == 9 && event.shiftKey == true)) {
             var inputs = $(this).parents("form").eq(0).find("input[type='text'], select");
             var idx = inputs.index(this);
             if (idx > 0) {
                 inputs[idx - 1].focus();
                 inputs[idx - 1].select();
             }
             return false;
         }

     });
        //For navigating using up and down arrow of the keyboard
        $(".table1 tr td input[type='text'], .table1 tr td select").keypress(
        function (event) {
            if ((event.keyCode == 40)) {
                if ($(this).parents("tr").next() != null) {
                    var nextTr = $(this).parents("tr").next();
                    var inputs = $(this).parents("tr").eq(0).find("input[type='text'], select");
                    var idx = inputs.index(this);
                    nextTrinputs = nextTr.find("input[type='text'], select");
                    if (nextTrinputs[idx] != null) {
                        nextTrinputs[idx].focus();
                        nextTrinputs[idx].select();
                        $(this).parents("tr").removeClass("selectedRow");
                        nextTr.addClass("selectedRow");
                    }
                }
                else {
                    $(this).focus();
                    $(this).select();
                    $(this).parents("tr").addClass("selectedRow");
                }
            }
            if ((event.keyCode == 38)) {
                if ($(this).parents("tr").next() != null) {
                    var nextTr = $(this).parents("tr").prev();
                    var inputs = $(this).parents("tr").eq(0).find("input[type='text'], select");
                    var idx = inputs.index(this);
                    nextTrinputs = nextTr.find("input[type='text'], select");
                    if (nextTrinputs[idx] != null) {
                        nextTrinputs[idx].focus();
                        nextTrinputs[idx].select();
                        $(this).parents("tr").removeClass("selectedRow");
                        nextTr.addClass("selectedRow");
                    }
                    return false;
                }
                else {
                    $(this).focus();
                    $(this).select();
                    $(this).parents("tr").addClass("selectedRow");
                }
            }

        });

    } catch (e) {
        alert(e.message);
    }

};

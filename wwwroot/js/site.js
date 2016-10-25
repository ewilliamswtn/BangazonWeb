// Write your Javascript code.
$(document).ready(function () {
  $("#CustomerId").on("change", function (e) {
    $.ajax({
      url: "/Customer/Activate",
      method: "POST",
      data: {
        "CustomerId": $(this).val() 
      }
    });
    location.reload();
  });
});
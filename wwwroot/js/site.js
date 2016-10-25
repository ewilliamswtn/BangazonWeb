// Write your Javascript code.
$(document).ready(function () {
  $("#CustomerId").on("change", function (e) {
    $.ajax({
      url: "/Customer/Activate",
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      data: {
        "CustomerId": $(this).val() 
      }
    });
    // location.reload();
  });
});
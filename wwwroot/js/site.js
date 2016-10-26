// Write your Javascript code.
$(document).ready(function () {
  $("#CustomerId").on("change", function (e) {
    $.ajax({
      url: `/Customer/Activate/${$(this).val()}`,
      method: "POST",
      dataType: "json",
      contentType: 'application/json; charset=utf-8'
    }).done(() => {
      location.reload();
    });
  });
});
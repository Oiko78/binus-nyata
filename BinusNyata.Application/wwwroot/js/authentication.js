/// <reference path="../lib/jquery/dist/jquery.js" />

$(".tooltip span")
  .filter(function () {
    return $(this).text().trim().length !== 0;
  })
  .parent(".tooltip")
  .parent(".icon")
  .prev()
  .addClass("error")
  .first()
  .addClass("active");

$(document).on("click", function (e) {
  if (!$(e.target).closest(".tooltip").not(this).length)
    $(".active").removeClass("active");
});

$("main .button").on("click", function (ev) {
  const el = $(this);
  const elInput = $("main input");
  const elIcon = $(".icon");
  const elLoading = document.createElement("span");
  elLoading.classList = "loading ph-spinner animate-spin";

  elIcon.css("background-color", "rgba(219, 219, 56, 0.8)");
  elInput.attr("readonly", true).removeClass("error");

  el.html(elLoading);
  el.attr("disabled", true);

  setTimeout(() => {
    el.text("Login");
    el.removeAttr("readonly");

    elInput.removeAttr("readonly", true).addClass("error");
  }, 1000);
});

$("main form").on("submit", function (ev) {
  ev.preventDefault();
  setTimeout(function () {
    document.querySelector("main form").submit();
  }, 500);
});

// $("main form input[type='text']").on("focus", function () {
//   const el = $(this);
//   const date = new Date(el.val());
//   el.attr("type", "date");
//   el.val(clearFormat(date));
//   console.log(clearFormat(date));
// });

// $("main form input[type='text']").on("blur", function () {
//   const el = $(this);
//   el.attr("type", "text");

//   const date = new Date(el.val());
//   el.val(
//     date.toLocaleDateString("id-ID", {
//       day: "2-digit",
//       month: "long",
//       year: "numeric",
//     })
//   );
//   console.log(el.val());
// });

function clearFormat(date) {
  const day = date.getDay().toString().padStart(2, 0);
  const month = date.getMonth().toString().padStart(2, 0);
  const year = date.getFullYear().toString().padStart(4, 0);
  return `${year}-${month}-${day}`;
}

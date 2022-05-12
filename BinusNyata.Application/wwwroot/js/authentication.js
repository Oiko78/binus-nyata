/// <reference path="../lib/jquery/dist/jquery.js" />

$(".tooltip span")
  .filter(function () {
    return $(this).text().trim().length !== 0;
  })
  .parent(".tooltip")
  .parent(".icon")
  .siblings("input")
  .addClass("error");

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

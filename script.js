function smoothScroll(idName) {

    var scrollIntoViewOptions = {
      block: "center",
      inline: "nearest",
      behavior: "smooth"
    };
    document.getElementById(idName).scrollIntoView(scrollIntoViewOptions);
}
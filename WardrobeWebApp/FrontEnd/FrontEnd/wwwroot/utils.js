function isHidden(elem) {
  return elem.classList.contains("hidden");
}

function hide(elem) {
  elem.classList.add("hidden");
}

function show(elem) {
  elem.classList.remove("hidden");
}
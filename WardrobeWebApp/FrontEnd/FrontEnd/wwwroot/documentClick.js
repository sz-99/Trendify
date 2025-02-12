
function getButtonId(dropdownId) {
  return dropdownId.replace("dropdown", "btn");
}

document.addEventListener("click", (e) => {
  let tagname = e.target.tagName.toLowerCase();
  if (tagname !== "button" && tagname !== "input") {
    try {
      let dropdowns = document.querySelectorAll("div.filter-dropdowns");

      dropdowns.forEach(dropdown => {
        if (!isHidden(dropdown)) {
          buttonId = getButtonId(dropdown.id);
          let button = document.getElementById(buttonId);
          button.click();
        }
      });

    } catch {

    }
  }
});
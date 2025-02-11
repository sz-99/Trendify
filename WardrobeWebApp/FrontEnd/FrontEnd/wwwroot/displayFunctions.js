var documentClicked = false;

function hideAllDropdowns(e) {
  if (e.target.id != "Category") {
    try {
      //document.querySelector("#Category-dropdown").setAttribute("hidden", "hidden")
      documentClicked = true;
    }
    catch {

    }
  }
  
}

document.addEventListener("click", (e) => {
  hideAllDropdowns(e);
})

function getDocumentClicked() {
  return documentClicked;
}

function setDocumentClicked(value) {
  documentClicked = value;
}
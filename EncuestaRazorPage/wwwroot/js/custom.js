document.addEventListener("DOMContentLoaded", function () {
    showTable(false);

    setTimeout(() => {
        showTable(true);
    }, 5000);

});

const showTable = (show) => {
  const showTableSection = document.querySelector(".show-table");
  const loadingSection = document.querySelector(".show-spinner");

  if (show) {
    showTableSection.style.display = "table";
    loadingSection.style.display = "none";
  } else {
    showTableSection.style.display = "none";
    loadingSection.style.display = "block";
  }
};

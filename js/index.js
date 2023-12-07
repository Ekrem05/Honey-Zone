const observer = new IntersectionObserver((entries) => {
  entries.forEach((entry) => {
    console.log(entry);
    if (entry.isIntersecting) {
      entry.target.classList.add("show");
    } else {
      entry.target.classList.remove("show");
    }
  });
});
const productCards = Array.from(document.querySelectorAll(".product-card"));
productCards.forEach((card) => {
  observer.observe(card);
});
const navigation = document.querySelector("#navigation-ref");
const links = Array.from(navigation.children);
links.forEach((li) => {
  li.addEventListener("click", () => {
    const childrenA = Array.from(li.children);
    childrenA[0].click();
  });
});
const quantityButtonsAndInput = {
  minus: document.querySelector(".quantity-box>.minus"),
  plus: document.querySelector(".quantity-box>.plus"),
  quantity: document.querySelector(".quantity-box>.quantity"),
};
minus.addEventListener("click", decreaseQuan);
plus.addEventListener("click", increaseQuan);

function decreaseQuan() {
  console.log(quantityButtonsAndInput.quantity.value);
  quantityButtonsAndInput.quantity.value = -1;
}

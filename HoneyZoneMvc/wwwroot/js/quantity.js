const quantityButtonsAndInput = {
  minus: document.querySelector(".quantity-box .minus"),
  plus: document.querySelector(".quantity-box .plus"),
  quantity: document.querySelector(".quantity-box .quantity"),
};
quantityButtonsAndInput.minus.addEventListener("click", decreaseQuan);
quantityButtonsAndInput.plus.addEventListener("click", increaseQuan);

function decreaseQuan() {
  console.log(quantityButtonsAndInput.quantity.value);
  const value = Number(quantityButtonsAndInput.quantity.innerHTML);
  if (value > 1) {
    quantityButtonsAndInput.quantity.innerHTML = value - 1;
  }
}
function increaseQuan() {
  console.log(quantityButtonsAndInput.quantity.innerHTML);
  const value = Number(quantityButtonsAndInput.quantity.innerHTML);
  quantityButtonsAndInput.quantity.innerHTML = value + 1;
}

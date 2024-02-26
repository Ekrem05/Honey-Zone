mainImage = document.querySelector(".image-container>img");
pics = document.querySelector(".more-pics");

Array.from(pics.children).forEach((image) => {
  image.addEventListener("click", showMe);
});

function showMe(e) {
  mainImage.src = e.currentTarget.src;
}
const image = new Image();
console.log(image);
image.src = mainImage.src;

// When the image is loaded, update the source and add a class to trigger transition
image.onload = function () {
  const imgElement = document.querySelector(".image-container>img");
  imgElement.src = this.src;
  imgElement.classList.add("image-loaded");
};

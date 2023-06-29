let slide_index = 0
let slide_play = true
let slides = document.querySelectorAll('.slide')

hideAllSlide = () =>{
	slides.forEach(e => {
		e.classList.remove('active')
	})
}

showSlide = () => {
	hideAllSlide()
	slides[slide_index].classList.add('active')
}

nextSlide = () => slide_index = slide_index + 1 === slides.length ? 0 : slide_index + 1

prevSlide = () => slide_index = slide_index - 1 < 0 ? slides.length - 1 : slide_index -1

//tam dung khi hover
document.querySelector('.slider').addEventListener('mouseover', () => slide_play = false)
//tiep tuc khi bo chuot
document.querySelector('.slider').addEventListener('mouseleave', () => slide_play = true)

//slider control
document.querySelector('.slide-next').addEventListener('click', () => {
	nextSlide()
	showSlide()
})
document.querySelector('.slide-prev').addEventListener('click', () => {
	prevSlide()
	showSlide()
})

showSlide()

// setInterval(() => {
// 	if(!slide_play) return
// 	showSlide()
// 	nextSlide()
// }, 3000);
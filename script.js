const data = [
  {
    percentage: 75,
    title: 'Title 1',
    paragraph: 'Paragraph 1',
    bulletPoints: ['Bullet 1-1', 'Bullet 1-2'],
  },
  {
    percentage: 50,
    title: 'Title 2',
    paragraph: 'Paragraph 2',
    bulletPoints: ['Bullet 2-1', 'Bullet 2-2'],
  },
  {
    percentage: 75,
    title: 'Title 1',
    paragraph: 'Paragraph 1',
    bulletPoints: ['Bullet 1-1', 'Bullet 1-2'],
  },
  // Add more data as needed
]

// Function to create a circle container
function createCircleContainer(percentage, title, paragraph, bulletPoints) {
  const mainContainer = document.getElementById('charts')

  const circleContainer = document.createElement('div')
  circleContainer.classList.add('circle-container')

  const circle = document.createElement('div')
  circle.classList.add('circle')

  const avatar = document.createElement('div')
  avatar.classList.add('avatar')

  const avatarIcon = document.createElement('i')
  avatarIcon.classList.add('fa-solid', 'fa-person-dress')

  const percentageElement = document.createElement('p')
  percentageElement.classList.add('percentage')
  percentageElement.textContent = `${percentage}%`

  const content = document.createElement('div')
  content.classList.add('content')
  content.innerHTML = `<h2>${title}</h2><p>${paragraph}</p>`

  const bulletPointsContainer = document.createElement('div')
  bulletPointsContainer.classList.add('bullet-points')

  const bulletPointsList = document.createElement('ul')
  bulletPoints.forEach((point) => {
    const li = document.createElement('li')
    li.textContent = point
    bulletPointsList.appendChild(li)
  })

  bulletPointsContainer.appendChild(bulletPointsList)

  avatar.appendChild(avatarIcon)
  circle.appendChild(avatar)
  circle.appendChild(percentageElement)
  circleContainer.appendChild(circle)
  circleContainer.appendChild(content)
  circleContainer.appendChild(bulletPointsContainer)

  mainContainer.appendChild(circleContainer)

  // Set the dynamic percentage in the circle
  avatar.style.width = `${percentage}%`
}

// Create dynamic containers based on the sample data
data.forEach((item) => {
  createCircleContainer(item.percentage, item.title, item.paragraph, item.bulletPoints)
})

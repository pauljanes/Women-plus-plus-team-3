google.charts.load('current', { packages: ['corechart', 'bar'] })
google.charts.setOnLoadCallback(drawImpactTrackingCharts)
google.charts.setOnLoadCallback(drawChart)

function smoothScroll(idName) {
  var scrollIntoViewOptions = {
    block: 'center',
    inline: 'nearest',
    behavior: 'smooth',
  }
  document.getElementById(idName).scrollIntoView(scrollIntoViewOptions)
}

function drawImpactTrackingCharts() {
  var data1 = google.visualization.arrayToDataTable([
    ['Job status', 'Number of people'],
    ['Landed a new job', 50],
    ['No change in job status', 70],
  ])

  var data2 = google.visualization.arrayToDataTable([
    ['Networking status', 'Number of people'],
    ['Expanded connections', 100],
    ['No change in connections', 20],
  ])

  var data3 = google.visualization.arrayToDataTable([
    ['Skill status', 'Number of people'],
    ['Acquired new skills', 50],
    ['No change in skills', 70],
  ])

  var options1 = {
    title: 'Participants that landed a new job within 3 months',
    colors: ['#347deb', '#dcdfe3'], // blue, grey,
    legend: 'none',
    is3D: true,
    pieStartAngle: 0,
    titleTextStyle: {
      fontSize: 16,
    },
  }
  var options2 = {
    title: 'Participants that expanded their networks',
    colors: ['#347deb', '#dcdfe3'], // blue, grey,
    legend: 'none',
    is3D: true,
    pieStartAngle: 0,
    titleTextStyle: {
      fontSize: 16,
    },
  }
  var options3 = {
    title: 'Participants that acquired new skills',
    colors: ['#347deb', '#dcdfe3'], // blue, grey,
    legend: 'none',
    is3D: true,
    pieStartAngle: 0,
    titleTextStyle: {
      fontSize: 16,
    },
  }

  var chart1 = new google.visualization.PieChart(document.getElementById('impact-chart1'))
  var chart2 = new google.visualization.PieChart(document.getElementById('impact-chart2'))
  var chart3 = new google.visualization.PieChart(document.getElementById('impact-chart3'))

  chart1.draw(data1, options1)
  chart2.draw(data2, options2)
  chart3.draw(data3, options3)
}

function drawChart() {
  var data1 = google.visualization.arrayToDataTable([
    ['Gender', 'Number of People'],
    ['Women', 100],
    ['Men', 20],
  ])

  var data2 = google.visualization.arrayToDataTable([
    ['Task', 'Hours per Day'],
    ['Women', 80],
    ['Men', 40],
  ])

  var options1 = {
    is3D: true,
    legend: 'none',
    title: 'Percentage of Women who Participated',
    colors: ['#347DEB', '#DCDFE3'],
    titleTextStyle: {
      fontSize: 16,
      letterSpacing: 1,
    },
  }

  var options2 = {
    is3D: true,
    legend: 'none',
    title: 'Percentage of participants that landed a new job within 3 months',
    colors: ['#347DEB', '#DCDFE3'],
    titleTextStyle: {
      fontSize: 16,
      letterSpacing: 1,
    },
  }
  var chart1 = new google.visualization.PieChart(document.getElementById('donutchart'))
  var chart2 = new google.visualization.PieChart(document.getElementById('donutcharts'))
  chart1.draw(data1, options1)
  chart2.draw(data2, options2)
}

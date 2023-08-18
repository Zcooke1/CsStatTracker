// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const api_url =
    "https://public-api.tracker.gg/v2/csgo/standard/profile/{platform}/{platformUserIdentifier}";

async function getapi(url) {

    //storing response
    const response = await fetch(url);

    //Storing data in form of JSON
    var data = await response.json();
    console.log(data);
    if (response) {
        hideloader();
    }
    show(data);
}

//Calling that async function
getapi(api_url);

//Function to hide the loader
function hideloader() {
    document.getElementById('loading').style.display = 'none';
}

//Function to define innerHTML for HTML table
getapi().then(data => {
    // Call the function to create the chart with the fetched data
    createChart(data);
});

// script.js

function createChart(data) {
    const labels = data.map(item => item.label); // Assuming your data has labels
    const values = data.map(item => item.value); // Assuming your data has corresponding values

    const ctx = document.getElementById('myChart').getContext('2d');
    const myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'API Data',
                data: values,
                borderColor: 'rgb(75, 192, 192)',
                fill: false,
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

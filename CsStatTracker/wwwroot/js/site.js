
function getProfileStats() {
   /* const response = await fetch(api_url, {
        headers: {
            'TRN-Api-Key': api_key
        }
    });

    const data = await response.json();

    if (response.ok) {
        hideloader();
        showProfileStats(data.data); // Assuming data.data contains profile stats
    } else {
        console.log("API request failed.");
    }*/

    let ProfileStats = {
    }
    ProfileStats.Wins = parseInt(document.getElementById('Wins').innerHTML);
    ProfileStats.Losses = parseInt(document.getElementById('Losses').innerHTML);
    ProfileStats.Winrate = parseInt(document.getElementById('Winrate').innerHTML);
    ProfileStats.Damage = parseInt(document.getElementById('Damage').innerHTML);
    ProfileStats.HSP = parseInt(document.getElementById('HSP').innerHTML);
    ProfileStats.RoundsPlayed = parseInt(document.getElementById('RoundsPlayed').innerHTML);
    ProfileStats.RoundsWon = parseInt(document.getElementById('RoundsWon').innerHTML);
    //console.log(ProfileStats);

    return ProfileStats;
}


function showProfileStats(profileData) {

    console.log(profileData)
    createChart([{ Label: 'Wins', Count: profileData.Wins }, { Label: 'Losses', Count: profileData.Losses },
    ]);
}

function createChart(segments) {
    // Assuming segments contains the necessary data for chart
    // Extract labels and values from the segments
    const labels = segments.map(segment => segment.Label);
    const values = segments.map(segment => segment.Count);
    console.log(labels);
    console.log(values);
    new Chart(document.getElementById('pieChart'), {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: 'Wins and Losses',
                data: values,
                backgroundColor: [
                    'rgb(255, 99, 132)',
                    'rgb(54,162, 235)',
                ],
                hoverOffset: 4
                
            }]
        },
        
    });
}



document.getElementById('btnGraph').onclick = function () {
    showProfileStats(getProfileStats());
};

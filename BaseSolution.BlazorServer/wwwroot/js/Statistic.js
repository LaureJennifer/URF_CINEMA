let generalBarChart;
let majorOverviewBarChartForAll;
let majorOverviewBarChart;

function clearChart(chart) {
    if (chart) {
        chart.destroy();
    }
}
function createStatisticForQuarterBarChart(labels, datasets, colors, data1, data2, data3, data4) {
    const ctx = document.getElementById('general-statistic-bar');

    clearChart(generalBarChart); // Clear the previous chart

    var options = {
        series: [{
            name: datasets[0],
            data: data1
        }, {
            name: datasets[1],
            data: data2
        }, {
            name: datasets[2],
            data: data3
        }, {
            name: datasets[3],
            data: data4
        }],
        chart: {
            type: 'bar',
            height: '100%'
        },
        plotOptions: {
            bar: {
                horizontal: false,
                endingShape: 'rounded',
                dataLabels: {
                    position: 'top',
                },
            },
        },
        dataLabels: {
            enabled: true,
            offsetY: 15,
            style: {
                fontSize: '1 rem',
                colors: ['#fff']
            }
        },
        colors: colors,
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: labels,
        },
        yaxis: {
            title: {
                //text: '$ (thousands)'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                //formatter: function (val) {
                //    return "$ " + val + " thousands"
                //}
            }
        }
    };

    generalBarChart = new ApexCharts(ctx, options);
    generalBarChart.render();
}

function createStatisticBarChart(colors, datasets, labels, data,id) {
    const ctx = document.getElementById(id);

    clearChart(majorOverviewBarChart); // Clear the previous chart

    var options = {
        series: [{
            name: labels,
            data: data
        }],
        chart: {
            type: 'bar',
            height: '100%'
        },
        colors: colors,
        
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: false,
                distributed: true,
                dataLabels: {
                    position: 'top',
                }
            }
        },
        dataLabels: {
            enabled: true,
            offsetY: 15,
            style: {
                fontSize: '1 rem',
                colors: ['#fff']
            }
        },
        xaxis: {
            categories: datasets,
        }
    };

    majorOverviewBarChart = new ApexCharts(ctx, options);
    majorOverviewBarChart.render();
}
function createStatisticBarChartForAll(colors, datasets, labels, data,id) {
    const ctx = document.getElementById(id);

    clearChart(majorOverviewBarChartForYear); // Clear the previous chart

    var options = {
        series: [{
            name: labels,
            data: data
        }],
        chart: {
            type: 'bar',
            height: '100%'
        },
        colors: colors,

        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: true,
                distributed: true,
                dataLabels: {
                    position: 'top',
                }
            }
        },
        dataLabels: {
            enabled: true,
            offsetY: 15,
            style: {
                fontSize: '1 rem',
                colors: ['#fff']
            }
        },
        xaxis: {
            categories: datasets,
        }
    };

    majorOverviewBarChartForAll = new ApexCharts(ctx, options);
    majorOverviewBarChartForAll.render();
}


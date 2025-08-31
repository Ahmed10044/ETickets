document.getElementById('year').textContent = new Date().getFullYear();

function toggleMobile() {
    const d = document.getElementById('mobileDrawer');
    d.classList.toggle('hidden');
}
document.getElementById('mobileMenuBtn').addEventListener('click', toggleMobile);

// Chart.js demo chart
const ctx = document.getElementById('salesChart').getContext('2d');
const salesChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: Array.from({ length: 30 }, (_, i) => `Day ${i + 1}`),
        datasets: [{
            label: 'Tickets sold',
            data: Array.from({ length: 30 }, () => Math.floor(Math.random() * 300) + 50),
            fill: true,
            tension: 0.3,
            backgroundColor: 'rgba(99,102,241,0.12)',
            borderColor: 'rgba(99,102,241,0.8)',
            pointRadius: 2
        }]
    },
    options: {
        plugins: { legend: { display: false } },
        scales: {
            x: { grid: { display: false } },
            y: { grid: { color: 'rgba(255,255,255,0.03)' } }
        }
    }
});
if (window.feather) feather.replace();

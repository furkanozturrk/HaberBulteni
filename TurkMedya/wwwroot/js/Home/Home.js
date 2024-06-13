function filterBy() {
    var categorySelection = document.getElementById("categorySelection").value;
    var searchText = document.getElementById("searchText").value;

    // Burada index action'ı çağrılacak ve seçilen kategori ve metin verisi gönderilecek
    window.location.href = '/Home/Index?pageNum=1&category=' + categorySelection + '&searchText=' + searchText;
}

function Details(itemId) {
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Home/Detail',
        data: { DetayId: itemId },
        success: function (result) {
            if (result != null) {
                alert(result.shortText);
            }
            else {
            alert("Detay bulunamadı.");
            }
        },
    });
}
 

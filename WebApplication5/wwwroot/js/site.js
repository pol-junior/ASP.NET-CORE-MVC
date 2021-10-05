
$('#my-flex-contenier').load('/Home/BicycleList');

$('#serch-text').on('input', function () {
    const text = $('#serch-text').val()
    $('#my-flex-contenier').load(`/Home/BicycleList/?serchText=${text}`);
})


$('#filtr-button').on('click', function () {

    const manufactureName = $('input[name="manufactureName"]:checked').val();

    
    const frameSize = $('input[name="frameSize"]:checked').val();
 
    const gearsQuantity = $('input[name="gearsQuantity"]:checked').val();
  
    
    $('#my-flex-contenier')
        .load(`/Home/BicycleList/?manufactureName=${manufactureName}&frameSize=${frameSize}&gearsQuantity=${gearsQuantity}`);


})



let count = 20
window.onscroll = function (ev) {

    if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight ) {

        $('#my-flex-contenier').load(`/Home/BicycleList/?pagenationNum=${count}`);

        count += 20;
    }   
};
button = $('.card__button');

button.on('click', function clicked() {
	$(this).addClass('card__button--triggered');
		
	$(this).off('click', clicked);

var count=5;
var counter=setInterval(timer, 1000);

function timer()
{
 
  count -= 1;
  if (count === -1)
  {
  	clearInterval(counter);
		
		setTimeout(function(){
			count = 5;
			document.getElementById("num").innerHTML=count;

			button.removeClass('card__button--triggered');
			button.on('click', clicked);
			
		}, 1);

     return;
  }
	document.getElementById("num").innerHTML = count;
	document.getElementById('btnstart').addClass('card__button--triggered');
	
}
	
});
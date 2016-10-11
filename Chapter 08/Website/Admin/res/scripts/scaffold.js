function CheckDelete()
{ 
	  return confirm('Delete this record? This action cannot be undone...'); 
}

function imposeMaxLength(e, Object, MaxLen, rowIndex)
{
	var keyCode = e.keyCode;
	var counter = document.getElementById('counter' + rowIndex);
	var charText = Object.value;
	var charCount = charText.length;
	var charRemain = MaxLen - charCount;
	counter.style.visibility = 'visible';
	if(keyCode == 8 || keyCode == 46)
	{
		if(charCount == MaxLen)
		{
			charRemain = 1;
		}
		else if(charCount == 0)
		{
			charRemain = MaxLen;
		}
		counter.innerHTML = charRemain;
		return true;
	}
	else
	{
		if(charRemain > 0)
		{
			counter.innerHTML = charRemain;
			return true;
		}
		else
		{
			Object.value = charText.substring(0, MaxLen);
			counter.innerHTML = '0';
			return false;
		}
	}
}
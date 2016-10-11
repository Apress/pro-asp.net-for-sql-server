function toggleAll(isChecked, control) 
{
   i = 0;
   var thisControl = document.getElementById(control + '_' + i);
   while(thisControl != null)
   {
        thisControl = document.getElementById(control + '_' + i);
        
        if(thisControl != null)
        {
			if(!thisControl.disabled)
			{
				thisControl.checked = isChecked;
			}
            i++;
        }
   }
}
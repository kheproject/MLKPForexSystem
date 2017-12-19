
function IsOneDecimalPoint(evt) 
{
                var charCode = (evt.which) ? evt.which : event.keyCode; // restrict user to type only one . point in number
                var parts = evt.srcElement.value.split('.');
                if(parts.length > 1 && charCode==46)
                    return false;
                return true;
}

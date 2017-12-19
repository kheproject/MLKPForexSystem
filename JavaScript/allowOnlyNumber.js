function allowOnlyNumber(evt)
{
  var charCode = (evt.which) ? evt.which : event.keyCode
  if (charCode > 8 && (charCode < 48 || charCode > 57 ) && (charCode < 96 || charCode > 106 ) && charCode > 13)
    return false;
  return true;
}
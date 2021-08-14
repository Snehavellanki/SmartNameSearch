// Write your Javascript code.

$(document).ready(function () {
    
    $("#SearchWords_GlobalSearch").autocomplete({
        source: '/api/AutoCompleteApi/autocompleteGlobal'
    });
    
  })

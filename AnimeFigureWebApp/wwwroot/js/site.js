function updateUrlWithFilters(searchTerm)
{

    var selectedBrands = [];
    $('input[type="checkbox"]:checked').each(function ()
    {

        selectedBrands.push($(this).attr('id'));

    });

    var url = 'Catalog?searchTerm=' + searchTerm;

    if (selectedBrands.length > 0)
    {

        url += '&brands=' + selectedBrands.join(',');

    }

    window.location.href = url;

}

document.getElementById("SearchbarInput").addEventListener("keyup", function (event)
{

    if (event.key === "Enter")
    {

        var searchTerm = $('input[name="MainSearchbar"]').val();
        updateUrlWithFilters(searchTerm);

        return false;

    }

});

document.querySelectorAll('input[type="checkbox"]').forEach(function (checkbox)
{
    document.querySelectorAll('input[type="checkbox"]').addEventListener('change', function ()
    {

        var searchTerm = $('input[name="MainSearchbar"]').val();
        updateUrlWithFilters(searchTerm);

    });

});
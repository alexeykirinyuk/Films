var url = window.location.href;
var arr = url.split("/");
var host = arr[0] + "//" + arr[2] + "/";

function href(path)
{
    document.location.href = host + path;
}

function hrefAction(controller, action, id)
{
    var uri = controller + "/" + action;

    if (null != id)
    {
        uri += "?id=" + id
    }

    href(uri);
}
function hrefStart()
{
    hrefAction("Start", "Index");
}
function hrefFilm(action, id)
{
    hrefAction("Films", action, id);
}
function hrefActor(action, id)
{
    hrefAction("Actors", action, id);
}

function search(count)
{
    var search = document.getElementById("search").value.toUpperCase();
    var tr = document.getElementById("table").getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++)
    {
        var td = tr[i].getElementsByTagName("td")[0];

        if (td)
        {
            var show = false;

            for (var j = 0; j < count; j++)
            {
                td = tr[i].getElementsByTagName("td")[j];
                show |= (td.innerHTML.toUpperCase().indexOf(search) > -1);
            }

            if (show)
            {
                tr[i].style.display = "";
            }
            else
            {
                tr[i].style.display = "none";
            }
        }
    }
}
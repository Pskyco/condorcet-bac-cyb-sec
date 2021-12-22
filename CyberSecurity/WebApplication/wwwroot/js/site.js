// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelectorAll('.api-button').forEach(item => {
    item.addEventListener('click', event => {
        // data-http-method => jquery => data("httpMethod")
        callApi($(item).data("host"), $(item).data("uri"), $(item).data("httpMethod"))
    })
})

function callApi(host, uri, methodName) {
    const resultSpan = document.getElementById('result');

    fetch(`${host}${uri}`,
        {
            method: methodName
        }).then(response => {
        if (response.ok) {
            response.text().then(text => {
                resultSpan.innerText = text;
            });
        }
        else {
            resultSpan.innerText = response.status;
        }
    })
        .catch(() => resultSpan.innerText = 'See F12 Console for errors');
}
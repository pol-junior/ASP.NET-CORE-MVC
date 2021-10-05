///*const { hide } = require("@popperjs/core");
var tokenKey = "access_token"

function createTableRow(bicycle) {
    const tr = document.createElement('tr')

    const titleTd = document.createElement('td')
    titleTd.append(bicycle.name)
    tr.append(titleTd)

    const modelTd = document.createElement('td')
    modelTd.append(bicycle.mnufacture)
    tr.append(modelTd)


    const priceTd = document.createElement('td')
    priceTd.append(bicycle.price)
    tr.append(priceTd)


    const frameSizeTD = document.createElement('td')
    frameSizeTD.append(bicycle.frameSize)
    tr.append(frameSizeTD)

    const wheelDiameterTD = document.createElement('td')
    wheelDiameterTD.append(bicycle.wheelDiameter)
    tr.append(wheelDiameterTD)

    const weightTD = document.createElement('td')
    weightTD.append(bicycle.weight)
    tr.append(weightTD)

    const imageUrlTD = document.createElement('td')
    const image = document.createElement('img')
    image.src = bicycle.iamgeUrl
    image.width = 30 
    imageUrlTD.append(image)
    tr.append(imageUrlTD)   

    const deleteTD = document.createElement('td')
    const deleteForm = document.createElement('form');
    const inputSubmit = document.createElement('button')
    inputSubmit.value = `${bicycle.bicycleID}`
    inputSubmit.classList.add('btn')
    inputSubmit.classList.add('btn-danger')
    inputSubmit.classList.add('delete-button')
    deleteForm.append(inputSubmit)
    deleteTD.append(deleteForm);
    inputSubmit.append('Delete')
    tr.append(deleteTD)
    const token = sessionStorage.getItem(tokenKey)
    inputSubmit.addEventListener('click', async function (e) {
        console.log(inputSubmit.value)
        await fetch(`/api/bicycle/${inputSubmit.value}`, {
            method: 'DELETE',
            headers: {
                'Authorization': 'bearer ' + token
            }
        })
    });

    const editTD = document.createElement('td')
    editBtn = document.createElement('btn')
    editBtn.classList.add('btn')
    editBtn.classList.add('btn-warning')
    editBtn.append('Edit')
    editTD.append(editBtn)
    tr.append(editTD)
    
    return tr
}




async function getBicycles() {

    const token = sessionStorage.getItem(tokenKey)
    const response = await fetch('/api/bicycle', {
        method: 'GET',
        headers: {
            'Authorization': 'bearer ' + token
        }
    })
    if (response.ok == true) {
        if (response.ok === true) {
            const bicycles = await response.json()
            let rows = document.querySelector('tbody')
            bicycles.forEach(bicycle => rows.append(createTableRow(bicycle)))
        }
    }

}

async function createBicycle(name, manufacture, price, frameSize, wheelDiameter, gearsQuantity, imageUrl, weight) {
    const token = sessionStorage.getItem(tokenKey)
    const response = await fetch('/api/bicycle', {
        method: 'POST',
        headers: {
            'Authorization': 'bearer ' + token,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify({
            name,
            Mnufacture:manufacture,
            IamgeUrl:imageUrl,
            price: +price,
            frameSize: + frameSize,
            wheelDiameter: + wheelDiameter,
            gearsQuantity: +gearsQuantity,
            weight:+weight
        })
    })

    if (response.ok === true) {
        const bicycle = await response.json()
        document.querySelector('tbody').append(createTableRow(bicycle))
    } else {
        document.getElementById('errors').innerHTML = ''

        const errorData = await response.json()
        console.log(errorData)
        console.log(errorData.errors)

        if (errorData) {
            if (errorData.errors) {
                for (let error in errorData.errors) {
                    showError(errorData.errors[error])
                }
            }


            document.getElementById('errors').style.display = 'block'
        }

    }
}

function showError(errors) {
    errors.forEach(error => {
        const p = document.createElement('p')
        p.append(error)
        document.getElementById('errors').append(p)
    })
}

document.forms['bicycleForm'].addEventListener('submit', function (e) {
    e.preventDefault()
    const form = document.forms['bicycleForm']
    const name = form.elements['name'].value
    const manufacture = form.elements['manufacture'].value
    const price = form.elements['price'].value
    const frmaSize = form.elements['frameSize'].value
    const weight = form.elements['weight'].value
    const wheelDiameter = form.elements['wheelDiameter'].value
    const gearsQuantity = form.elements['gearsQuantity'].value
    const imageUrl = form.elements['imageUrl'].value

    createBicycle(name, manufacture, price, frmaSize, wheelDiameter, gearsQuantity, imageUrl, weight)
})


async function getTokenAsync(userName, password) {
    const credentials = {
        userName: userName,
        password: password
    }

    console.log(credentials)    
    const response = await fetch('api/Account/Token', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    })

    console.log(response)
    const data = await response.json()
    if (response.ok === true) {
        sessionStorage.setItem(tokenKey, data.access_token)
        getBicycles()
    } else {
        console.log(response.status, response.errorText)
    }
}

var loginBtn = document.getElementById('loginBtn')
loginBtn.addEventListener('click', function () {

    var login = document.getElementById('login').value
    var password = document.getElementById('password').value
  getTokenAsync(login,password)

});

getBicycles()
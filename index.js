const addBtn = document.getElementById('addBtn');
const input = document.getElementById('input');
const resultBtn = document.getElementById('resultBtn');
const setDisplay = document.getElementById('set-display');
const content = document.getElementById('content');
const inputDiv = document.getElementById('input-div');

const set = new Set();
addBtn.addEventListener('click', addToSet);
input.addEventListener('keydown', (e) => 
{
    if(e.key == "Enter") 
        addToSet();
});
resultBtn.addEventListener('click', createPowerSet);




function addToSet()
{
    if(set.size > 12)
    {
        alert("Set size is limited to 12 elements");
        return;
    }
    if(input.value)
    {
        set.add(input.value);
        input.value = "";
        setDisplay.innerText = Array.from(set).join(", ");
    }
}


const powerSet = [];

function createPowerSet()
{
    let elements = [...set];

    for(let size = 1; size < elements.length; size++)
    {
        subsetElements = Array(size);
        combinations(elements, subsetElements, 0, elements.length, 0, size);
    }
    if(elements.length != 0)
        powerSet.push(new Set(elements));

    displayPowerSet();
}

function combinations(elements, subsetElements, start, end, index, size)
{
    if(index == size)
    {
        powerSet.push(new Set(subsetElements));
        return;
    }

    for(let i = start; i < end && end - i >= size - index; i++)
    {
        subsetElements[index] = elements[i];
        combinations(elements, subsetElements, i + 1, end, index + 1, size);
    }
}

function displayPowerSet()
{
    content.removeChild(inputDiv);
    const display = document.createElement('div');
    display.id = "display";
    let str = "P(A) = { {∅}, ";
    for(let i = 0; i < powerSet.length; i++)
    {
        str += "{ ";
        for(let element of powerSet[i])
        {
            str += element + ", ";
        }
        str = str.slice(0, -2);
        str += " }, ";
    }
    str = str.slice(0, -2);
    str += " }"
    display.innerText = str;
    content.appendChild(display);
    const backBtn = document.createElement('a');
    backBtn.href = "index.html";
    backBtn.innerText = "Back to Home Page";
    backBtn.classList.add("btn", "btn-primary", "mt-5");
    content.appendChild(backBtn);
}




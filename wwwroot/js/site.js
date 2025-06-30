// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.cart').click(function () {
        $(this).find('.cart-products').slideToggle();
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const mode = document.body.getAttribute("data-mode"); // "create" or "update"
    const prefix = mode === "update" ? "Cart.CartItems" : "CartItems";

    let productIndex = document.querySelectorAll("#cart-table tbody tr").length;

    const addButton = document.getElementById("add-product");
    const select = document.getElementById("product-select");
    const quantityInput = document.getElementById("quantity");
    const tableBody = document.querySelector("#cart-table tbody");
    const container = document.getElementById("cart-items-container");

    if (!addButton || !select || !quantityInput || !tableBody || !container) return;

    addButton.addEventListener("click", function () {
        const selectedOption = select.options[select.selectedIndex];
        const productId = select.value;
        const productTitle = selectedOption.getAttribute("data-title");
        const quantity = quantityInput.value;

        if (!productId || quantity < 1) return;

        // Create table row
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${productTitle}</td>
            <td>
                <input type="number" class="form-control quantity-input" name="${prefix}[${productIndex}].Quantity"
                       value="${quantity}" min="1" data-index="${productIndex}" />
            </td>
            <td>
                <button type="button" class="btn btn-sm btn-danger remove-row">Remover</button>
            </td>
        `;
        tableBody.appendChild(row);

        // Create hidden inputs
        const hiddenDiv = document.createElement("div");
        hiddenDiv.id = `cart-item-${productIndex}`;
        hiddenDiv.innerHTML = `
            <input type="hidden" name="${prefix}[${productIndex}].ProductId" value="${productId}" />
            <input type="hidden" class="hidden-quantity" value="${quantity}" />
        `;
        container.appendChild(hiddenDiv);

        productIndex++;

        // Reset form
        select.selectedIndex = 0;
        quantityInput.value = 1;
    });

    // Sync quantity changes
    tableBody.addEventListener("input", function (e) {
        if (e.target.classList.contains("quantity-input")) {
            const index = e.target.getAttribute("data-index");
            const newQuantity = e.target.value;
            const hiddenQuantityInput = document.querySelector(`#cart-item-${index} .hidden-quantity`);
            if (hiddenQuantityInput) {
                hiddenQuantityInput.value = newQuantity;
            }
        }
    });

    // Remove row and hidden inputs
    tableBody.addEventListener("click", function (e) {
        if (e.target.classList.contains("remove-row")) {
            const row = e.target.closest("tr");
            const input = row.querySelector(".quantity-input");
            const index = input?.getAttribute("data-index");
            if (index) {
                const hiddenDiv = document.getElementById(`cart-item-${index}`);
                if (hiddenDiv) hiddenDiv.remove();
            }
            row.remove();
        }
    });
});
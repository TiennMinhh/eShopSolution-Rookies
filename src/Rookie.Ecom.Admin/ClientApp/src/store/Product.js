const requestProductType = 'REQUEST_PRODUCTS';
const receiveProductType = 'RECEIVE_PRODUCTS';
const updateProductType = 'UPDATE_PRODUCT'
const initialState = { products: [], isLoading: false };

export const actionCreators = {
    requestProducts: page => async (dispatch, getState) => {
        if (page === getState().products.page) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestProductType, page });

        const url = `api/Product/find?page=${page}`;
        const response = await fetch(url);
        const data = await response.json();
        const products = data.items;
        dispatch({ type: receiveProductType, page, products });
    }

};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestProductType) {
        return {
            ...state,
            page: action.page,
            isLoading: true
        };
    }

    if (action.type === receiveProductType) {
        return {
            ...state,
            page: action.page,
            products: action.products,
            isLoading: false
        };
    }

    return state;
};

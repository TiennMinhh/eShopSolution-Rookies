const requestProductImageType = 'REQUEST_PRODUCTIMAGES';
const receiveProductImageType = 'RECEIVE_PRODUCTIMAGES';
const initialState = { productimages: [], isLoading: false };

export const actionCreators = {
    requestProductImages: page => async (dispatch, getState) => {
        if (page === getState().productimages.page) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestProductImageType, page });

        const url = `api/ProductImage/find?page=${page}`;
        const response = await fetch(url);
        const data = await response.json();
        const productimages = data.items;
        dispatch({ type: receiveProductImageType, page, productimages });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestProductImageType) {
        return {
            ...state,
            page: action.page,
            isLoading: true
        };
    }

    if (action.type === receiveProductImageType) {
        return {
            ...state,
            page: action.page,
            productimages: action.productimages,
            isLoading: false
        };
    }

    return state;
};

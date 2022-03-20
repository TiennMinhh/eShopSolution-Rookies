import React from 'react';
import {
    NavItem,
    NavLink,
    Nav
} from 'reactstrap';
import { Link } from 'react-router-dom';
import './SideBar.css';
import classNames from "classnames";
import { connect } from 'react-redux';

class SideBar extends React.Component {
    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            isOpen: false
        };
    }
    toggle() {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
    render() {
        const { isOpen, toggle } = this.props
        return (
            <div className={classNames("sidebar", { "is-open": isOpen })}>                
                <div className="side-menu">
                    <Nav vertical className="list-unstyled pb-3">                                  
                        <NavItem>
                            <NavLink tag={Link} to="/category">
                               List Category
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/addcategory">
                                Add Category
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/updatecategory">
                                Update Category
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/product">
                               View Product
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/addproduct">
                                Add Product
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/updateproduct">
                                Update Product
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/productimage">
                                View Product Image
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/addproductimage">
                                Add Product Image
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/updateproductimage">
                                Update Product Image
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/user">
                                List User
                            </NavLink>
                        </NavItem>

                       {/* <NavItem>
                            <NavLink tag={Link} to="/counter">
                               View Counter
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/fetch-data">
                              View Fetch data
                            </NavLink>
                        </NavItem>*/}
                    </Nav>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        user: state.oidc.user,
        isAuthenticated: state.oidc.user && !state.oidc.user.expired
    };
}

function mapDispatchToProps(dispatch) {
    return {
        dispatch
    };
}


export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SideBar);

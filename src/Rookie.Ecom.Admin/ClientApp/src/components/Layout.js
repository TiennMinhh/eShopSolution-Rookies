import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu/NavMenu';
import SideBar from './NavMenu/SideBar';


export default props => (
    <div>
        <NavMenu />
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-2">
                <SideBar />
            </div>
            <div class="col-md-9">
                <Container>
                    {props.children}
                </Container>
            </div>
        </div>
    </div>
);

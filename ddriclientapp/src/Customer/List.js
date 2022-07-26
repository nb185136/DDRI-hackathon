import React, { Component } from 'react';  
import axios from 'axios';  
import Table from './Table';  
  
export default class list extends Component {  
  
  constructor(props) {  
    console.log("hi");
      super(props);  
      this.state = {business: []};  
    }  
    componentDidMount(){  

      axios.get('http://localhost/DDRIAPI/api/Customer/details')  
        .then(response => {  
          this.setState({ business: response.data });  
  
        })  
        .catch(function (error) {  
          console.log(error);  
        })  
    }  
      
    tabRow(){  
      return this.state.business.map(function(object, i){  
          return <Table obj={object} key={i} />;  
      });  
    }  
  
    render() {  
      return (  
        <div>  
          <h4 align="center">Customer List</h4>  
          <table className="table table-striped" style={{ marginTop: 10 }}>  
            <thead>  
              <tr>  
                <th>FirstName</th>  
                <th>LastName</th>  
                <th>State</th>  
                <th>City</th>  
                <th colSpan="4">Action</th>  
              </tr>  
            </thead>  
            <tbody>  
             { this.tabRow() }   
            </tbody>  
          </table>  
        </div>  
      );  
    }  
  }  
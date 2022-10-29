import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { provinces: [], cities: [], loading: true };
  }

  componentDidMount() {
    this.populateProvinceData();
  }

  static renderProvincesTable(provinces, cities) {
    return (
      <>
        <h3>Provinces</h3>
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
          <tr>
            <th>Province Code</th>
            <th>Province Name</th>
          </tr>
          </thead>
          <tbody>
          {provinces.map(province =>
              <tr key={province.provinceCode}>
                <td>{province.provinceCode}</td>
                <td>{province.provinceName}</td>
              </tr>
          )}
          </tbody>
        </table>
        <h3>Cities</h3>
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
          <tr>
            <th>City Id</th>
            <th>City Name</th>
            <th>Population</th>
            <th>Province Code</th>
          </tr>
          </thead>
          <tbody>
          {cities.map(city =>
              <tr key={city.cityId}>
                <td>{city.cityId}</td>
                <td>{city.cityName}</td>
                <td>{city.population}</td>
                <td>{city.provinceCode}</td>
              </tr>
          )}
          </tbody>
        </table>
      </>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderProvincesTable(this.state.provinces, this.state.cities);

    return (
      <div>
        <h1 id="tabelLabel" >Provinces and Cities</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateProvinceData() {
    const token = await authService.getAccessToken();
    const options = {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    };
    const provinceResponse = await fetch('province', options);
    const provincesData = await provinceResponse.json();

    const cityResponse = await fetch('city', options);
    const citiesData = await cityResponse.json();

    this.setState({ provinces: provincesData, cities: citiesData, loading: false });
  }
}

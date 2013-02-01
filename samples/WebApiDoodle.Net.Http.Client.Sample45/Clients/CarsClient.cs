﻿using System.Net.Http;
using System.Threading.Tasks;
using WebApiDoodle.Net.Http.Client.Model;
using WebApiDoodle.Net.Http.Client.Sample45.Models;
using WebApiDoodle.Net.Http.Client.Sample45.RequestCommands;

namespace WebApiDoodle.Net.Http.Client.Sample45.Clients {

    public class CarsClient : HttpApiClient<Car, int>, ICarsClient {

        // TODO: Handle exceptions with HttpApiError.
        // TODO: Handle response disposition.

        private const string BaseUriTemplate = "api/cars";
        public CarsClient(HttpClient httpClient) 
            : base(httpClient) {
        }

        /// <summary>
        /// Gets the cars list.
        /// </summary>
        /// <param name="paginationCmd"></param>
        /// <returns></returns>
        /// <exception cref="WebApiDoodle.Net.Http.Client.HttpApiRequestException">
        /// The request has completed with a non-success status code.
        /// </exception>
        public async Task<PaginatedDto<Car>> GetCars(PaginatedRequestCommand paginationCmd) {

            var apiResponse = await base.GetAsync(BaseUriTemplate, paginationCmd);
            if (apiResponse.IsSuccess) { 

                return apiResponse.Model;
            }

            throw new HttpApiRequestException(
                string.Format("Response status code does not indicate success: {0} ({1})", (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase),
                apiResponse.Response.StatusCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        /// <exception cref="WebApiDoodle.Net.Http.Client.HttpApiRequestException">
        /// The request has completed with a non-success status code.
        /// </exception>
        public async Task<Car> GetCar(int carId) {

            var apiResponse = await base.GetSingleAsync(string.Concat(BaseUriTemplate, "/{id}"), carId);
            if (apiResponse.IsSuccess) {

                return apiResponse.Model;
            }

            throw new HttpApiRequestException(
                string.Format("Response status code does not indicate success: {0} ({1})", (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase),
                apiResponse.Response.StatusCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        /// <exception cref="WebApiDoodle.Net.Http.Client.HttpApiRequestException">
        /// The request has completed with a non-success status code.
        /// </exception>
        public async Task<Car> AddCar(Car car) {

            var apiResponse = await base.PostAsync(BaseUriTemplate, car);
            if (apiResponse.IsSuccess) {

                return apiResponse.Model;
            }

            throw new HttpApiRequestException(
                string.Format("Response status code does not indicate success: {0} ({1})", (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase),
                apiResponse.Response.StatusCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        /// <exception cref="WebApiDoodle.Net.Http.Client.HttpApiRequestException">
        /// The request has completed with a non-success status code.
        /// </exception>
        public async Task<Car> UpdateCar(int carId, Car car) {

            var apiResponse = await base.PutAsync(string.Concat(BaseUriTemplate, "/{id}"), carId, car);
            if (apiResponse.IsSuccess) {

                return apiResponse.Model;
            }

            throw new HttpApiRequestException(
                string.Format("Response status code does not indicate success: {0} ({1})", (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase),
                apiResponse.Response.StatusCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        /// <exception cref="WebApiDoodle.Net.Http.Client.HttpApiRequestException">
        /// The request has completed with a non-success status code.
        /// </exception>
        public async Task RemoveCar(int carId) {

            var apiResponse = await base.DeleteAsync(string.Concat(BaseUriTemplate, "/{id}"), carId);
            if (!apiResponse.IsSuccess) {

                throw new HttpApiRequestException(
                    string.Format("Response status code does not indicate success: {0} ({1})", (int)apiResponse.Response.StatusCode, apiResponse.Response.ReasonPhrase),
                    apiResponse.Response.StatusCode);
            }
        }
    }
}
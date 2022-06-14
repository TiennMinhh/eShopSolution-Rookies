using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Products, t => t.Ignore());

            CreateMap<ProductDto, Product>()
                .ForMember(d => d.Brand, t => t.Ignore());

            CreateMap<ProductPictureDto, ProductPicture>();
            CreateMap<AddressDto, Address>();
            CreateMap<BrandDto, Brand>();
            CreateMap<CartDto, Cart>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<ProductFeedBackDto, ProductFeedBack>();
            CreateMap<RoleDto, Role>();
            CreateMap<SlideDto, Slide>();
            CreateMap<UserDto, User>();
            CreateMap<UserRoleDto, UserRole>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductPicture, ProductPictureDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<ProductFeedBack, ProductFeedBackDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Slide, SlideDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
